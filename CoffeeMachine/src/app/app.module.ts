import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';


import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { OrderComponent } from './order/order.component';
import { ConfigComponent } from './config/config.component';
import { ReportComponent } from './report/report.component';

import { OfficePantryService } from './services/office-pantry.service';

import { ChartsModule } from 'ng2-charts';

const appRoutes: Routes = [
    { path: 'home', component: OrderComponent },
    { path: 'config', component: ConfigComponent },
    { path: 'report', component: ReportComponent },
    { path: '', redirectTo: '/home', pathMatch: 'full' }
];

@NgModule({
    declarations: [
        AppComponent,
        OrderComponent,
        ConfigComponent,
        ReportComponent
    ],
    imports: [
        RouterModule.forRoot(
            appRoutes,
            { enableTracing: true } // <-- debugging purposes only
        ),
        BrowserModule,
        FormsModule,
        HttpModule,
        ChartsModule
    ],
    providers: [OfficePantryService],
    bootstrap: [AppComponent]
})
export class AppModule { }
