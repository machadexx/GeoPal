import { AfterViewInit, Component, OnInit } from '@angular/core';
import { TitleStrategy } from '@angular/router';
import * as L from 'leaflet';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.scss'],
})
export class MapComponent  implements AfterViewInit  {
  private static map: L.Map;
  msgFromMapChild: any[];

  constructor(){
    this.msgFromMapChild=[]
  }

  ngAfterViewInit(): void {
    this.initMapDefaultLeaflet();
    MapComponent.map.on('click', (ev) => {
      if(this.msgFromMapChild.length > 0){
        this.msgFromMapChild.pop();
      }
      this.msgFromMapChild.push(ev.latlng);
    })
    MapComponent.invalidadeSize();
  }

  private initMapDefaultLeaflet(): void{
    MapComponent.map = L.map('map')
    .setView(
      [41.169385019216094, -8.667400178166359],
      15);
      const tiles = L.tileLayer(
        'https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png',
        {
          maxZoom: 19,
          minZoom: 3,
          attribution: 'Map data &copy; <a href="https://www.openstreetmap.org/">OpenStreetMap</a> contributors'
        }).addTo(MapComponent.map);

      // var ponto = new map.LonLat(41.1775378587739, -8.682495652809997). transform(new L.map.Projection("EPSG:4326"))
      // MapComponent.map.addLayer(ponto)
  }

  static invalidadeSize(){
    setTimeout(() => {
      MapComponent.map.invalidateSize();
    }, 500);
  }
}