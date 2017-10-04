export interface ISupplies
{
    id: string;
    description: string;
    units: number;
    officePantry: IOfficePantry;
}

export interface IOfficePantry
{
    pantryId: string;
    pantry: string;
    officeId: string;
    office: string;
}

export interface ICoffeeList
{
    id: string;
    name: string;
    unitsOfBeans: number;
    unitsOfSugar: number;
    unitsOfMilk: number;
}

export interface IOrder
{
    coffeeId: string;
    pantryId: string;
}

export interface IOrderHistory
{
    coffee: string;
    pantry: string;
    office: string;
    orderDate: Date;
}