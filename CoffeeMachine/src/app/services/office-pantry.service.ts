import { Injectable } from '@angular/core';
import { Http, RequestOptions, Headers } from '@angular/http';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';
import { IOrder } from '../types/types';

//const baseApiUrl = 'http://localhost:5000';

@Injectable()
export class OfficePantryService{
    constructor(private _httpService: Http) { }

    getOrderData(): Observable<any> {
        return this
            ._httpService
            .get('/api/home')
            .map((response) => response.json());
    }

    getSupplies(pantry): Observable<any> {
        return this
            ._httpService
            .get('/api/supply/'+ pantry)
            .map((response) => response.json());
    }

    saveOrder(order: IOrder): Observable<any> {
        return this
            ._httpService
            .post('/api/order/saveorder', order);
    }

    refillSupplies(pantry: string): Observable<any> {

        let headers = new Headers({ 'Content-Type': 'application/json' });

        return this
            ._httpService
            .put('/api/supply/refillsupplies/', 
                { 'pantryId': pantry}
            , { headers: headers })
            .map((response) => response.json());
    }

    getOrderHistory(): Observable<any> {
        return this
            ._httpService
            .get('/api/order/getorderhistory')
            .map((response) => response.json());
    }

}
