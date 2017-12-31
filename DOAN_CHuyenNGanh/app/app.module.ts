import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent }  from './app.component';
import { HuydepComponent } from './huydep.component';

@NgModule({
  imports:      [ BrowserModule ],
  declarations: [AppComponent, HuydepComponent],
  bootstrap:    [ AppComponent ]
})
export class AppModule { }
