import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MapComponent } from '../map/map.component';



@NgModule({
  declarations: [MapaModule.mapa],
  imports: [
    CommonModule
  ],
  exports: [MapaModule.mapa]
})
export class MapaModule { 
  static mapa = MapComponent;
}
