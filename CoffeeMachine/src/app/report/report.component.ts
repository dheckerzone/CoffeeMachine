import { Component, OnInit } from '@angular/core';
import { OfficePantryService } from '../services/office-pantry.service';
import { IOrderHistory } from '../types/types';
import Chart from 'chart.js';

@Component({
    selector: 'app-report',
    templateUrl: './report.component.html',
    styleUrls: ['./report.component.css']
})
export class ReportComponent implements OnInit {
    Orders: IOrderHistory[];
    CoffeeLabels: string[];
    DoubleAmericanoCount: number;
    FlatWhiteCount: number;
    SweetLatteCount: number;
    ManilaPantryACount: number;
    ManilaPantryBCount: number;
    SydneyPantryACount: number;

    constructor(private _officePantrySvc: OfficePantryService) { }

    // Pie
    public pieChartLabels: string[] = ['Double Americano', 'Flat White', 'Sweet Latte'];
    public pieChartData: number[] = [this.DoubleAmericanoCount, this.FlatWhiteCount, this.SweetLatteCount];

    public pieChartLabelsPerPantry: string[] = ['Manila - Pantry A', 'Sydney - Pantry A', 'Manila - Pantry B'];
    public pieChartDataPerPantry: number[] = [this.ManilaPantryACount, this.SydneyPantryACount, this.ManilaPantryBCount];

    public pieChartType: string = 'pie';

    // events
    public chartClicked(e: any): void {
        console.log(e);
    }

    public chartHovered(e: any): void {
        console.log(e);
    }

    ngOnInit()
    {
        this._officePantrySvc.getOrderHistory().subscribe(orders =>
        {
            this.Orders = orders;
            this.DoubleAmericanoCount = this.Orders.filter(o => o.coffee === 'Double Americano').length;
            this.SweetLatteCount = this.Orders.filter(o => o.coffee === 'Sweet Latte').length;
            this.FlatWhiteCount = this.Orders.filter(o => o.coffee === 'Flat White').length;
            this.pieChartData = [this.DoubleAmericanoCount, this.FlatWhiteCount, this.SweetLatteCount];

            this.ManilaPantryACount = this.Orders.filter(o => o.pantry === 'Manila - Pantry A').length;
            this.SydneyPantryACount = this.Orders.filter(o => o.pantry === 'Sydney - Pantry A').length;
            this.ManilaPantryBCount = this.Orders.filter(o => o.pantry === 'Manila - Pantry B').length;
            this.pieChartDataPerPantry = [this.ManilaPantryACount, this.SydneyPantryACount, this.ManilaPantryBCount];
        });
        
    }
}
