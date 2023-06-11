import { AfterViewChecked, Component, OnInit, ViewChild } from '@angular/core';
import { MapComponent } from './map.component';

@Component({
  selector: 'app-map-page',
  templateUrl: './map.page.html',
  styleUrls: ['./map.page.scss'],
})
export class MapPage implements OnInit{
  @ViewChild(MapComponent, {static: false})
  childMap!: MapComponent;
  msgFromChildMap: any;
  
  msgErros = '';

  constructor() { }

  ngOnInit() {
  }

  // buscaValorMapChild(){
  //   if(this.msgFromChildMap !== null && this.msgFromChildMap !== undefined){
  //     this.TransformaGuardaCoordenadas(this.msgFromChildMap.toString());
  //   }
  // }
}
