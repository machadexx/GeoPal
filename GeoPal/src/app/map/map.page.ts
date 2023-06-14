import { AfterViewChecked, AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MapComponent } from './map.component';

@Component({
  selector: 'app-map-page',
  templateUrl: './map.page.html',
  styleUrls: ['./map.page.scss'],
})
export class MapPage implements OnInit, AfterViewInit{
  @ViewChild(MapComponent, {static: false})
  childMap!: MapComponent;
  msgFromChildMap: any;

  meusAmigos = [];
  msgErros = '';

  novaInsercao = false;

  OnNewAmigo() {
    this.novaInsercao = true;
    setTimeout(() => {
      this.msgFromChildMap = this.childMap.msgFromMapChild;
    }, 0);
  }

  constructor() { }

  ngOnInit() {
  }

  ngAfterViewInit(){

  }

  buscaValorMapChild(){
    if(this.msgFromChildMap !== null && this.msgFromChildMap !== undefined){
      console.log('asd');
      console.log(this.msgFromChildMap.toString());
    }
  }
}
