import { Component, OnInit, Inject } from '@angular/core';
import { OfficePantryService } from '../services/office-pantry.service';
import { ISupplies, ICoffeeList, IOrder } from '../types/types';
import Chart from 'chart.js';

@Component({
    selector: 'app-order',
    templateUrl: './order.component.html',
    styleUrls: ['./order.component.css']
})
export class OrderComponent implements OnInit {
    Order: any = [];
    CoffeeList: ICoffeeList[] = [];
    Supplies: ISupplies[] = [];
    SelectedPantry: any;
    RemainingBean: number;
    RemainingSugar: number;
    RemainingMilk: number;

    public pieChartLabelsSupplies: string[] = ['Beans', 'Milk', 'Sugar'];
    public pieChartDataSupplies: number[] = [this.RemainingBean, this.RemainingMilk, this.RemainingSugar];

    public pieChartType: string = 'pie';

    constructor(private _officePantrySvc : OfficePantryService) { }

    ngOnInit() {
        this._officePantrySvc.getOrderData().subscribe(order =>
        {
            this.Order = order;
            this.CoffeeList = order.coffeeList;
            this.SelectedPantry = this.Order.officePantryList[0].pantry;
            this.onSelectedPantryChange(this.SelectedPantry);
        });
    }

    onSelectedPantryChange(pantry) {
        this.SelectedPantry = pantry;
        this._officePantrySvc.getSupplies(pantry).subscribe(
            supply => {
                this.Supplies = supply;
                this.updateSupply();
            }
        );
    }

    getRemainingCoffee(coffee: string)
    {
        let currentCoffee = this.CoffeeList.find(c => c.name === coffee);

        let cupsPerIngredient: number[] = [];

        if (currentCoffee.unitsOfBeans > 0)
            cupsPerIngredient.push(this.RemainingBean / currentCoffee.unitsOfBeans);

        if (currentCoffee.unitsOfMilk > 0)
            cupsPerIngredient.push(this.RemainingMilk / currentCoffee.unitsOfMilk); 

        if (currentCoffee.unitsOfSugar > 0)
            cupsPerIngredient.push(this.RemainingSugar / currentCoffee.unitsOfSugar);

        let result = Math.trunc(Math.min.apply(Math, cupsPerIngredient));

        if (isNaN(result))
            return 0;

        return result;
    }

    getCoffee(coffee: string)
    {
        if (this.getRemainingCoffee(coffee) > 0)
        {
            let currentCoffee = this.CoffeeList.find(c => c.name === coffee);
            this.Supplies.find(s => s.description === "Beans").units -= currentCoffee.unitsOfBeans;
            this.Supplies.find(s => s.description === "Milk").units -= currentCoffee.unitsOfMilk;
            this.Supplies.find(s => s.description === "Sugar").units -= currentCoffee.unitsOfSugar;
            this.updateSupply();

            let order: any = {};

            order.coffeeId = currentCoffee.id;
            order.pantryId = this.Order.officePantryList.find(p=> p.pantry === this.SelectedPantry).pantryId;

            this._officePantrySvc.saveOrder(order).subscribe(o => { console.log(o); });
        }
    }

    updateSupply()
    {
        if (this.Supplies.length > 0) {
            this.RemainingBean = this.Supplies.find(s => s.description == "Beans").units;
            this.RemainingMilk = this.Supplies.find(s => s.description == "Milk").units;
            this.RemainingSugar = this.Supplies.find(s => s.description == "Sugar").units;

            this.pieChartDataSupplies = [this.RemainingBean, this.RemainingMilk, this.RemainingSugar];
        }
    }

    refillSupplies(event)
    {
        event.preventDefault();

        let pantry: any = this.Order.officePantryList[0].pantryId;

        this._officePantrySvc.refillSupplies(pantry).subscribe(supply => {
            this.Supplies = supply;
            this.updateSupply();
        });
    }
}
