import { AfterViewInit, Component, EventEmitter, Output } from '@angular/core';
import * as L from 'leaflet';

@Component({
  selector: 'app-mapa-profile',
  templateUrl: './mapa-profile.component.html',
  styleUrls: ['./mapa-profile.component.scss'],
})
export class MapaProfileComponent  implements AfterViewInit {
  public static map: L.Map;
  private static marker: L.Marker;
  msgFromMapChild: any[];

  @Output() locationConfirmed: EventEmitter<any> = new EventEmitter<any>();

  constructor() {
    this.msgFromMapChild = [];
  }

  ngAfterViewInit(): void {
    this.initMapDefaultLeaflet();
    MapaProfileComponent.map.on('click', (ev) => {
      if (this.msgFromMapChild.length > 0) {
        this.msgFromMapChild.pop();
      }
      console.log(ev.latlng);
      this.locationConfirmed.emit(ev.latlng);

      // Remove o marcador anterior, se existir
      if (MapaProfileComponent.marker) {
        MapaProfileComponent.map.removeLayer(MapaProfileComponent.marker);
      }

      // Adiciona o novo marcador na posição selecionada
      MapaProfileComponent.marker = L.marker(ev.latlng).addTo(MapaProfileComponent.map);
    });
    MapaProfileComponent.invalidateSize();
  }

  private initMapDefaultLeaflet(): void {
    MapaProfileComponent.map = L.map('map').setView([41.169385019216094, -8.667400178166359], 15);
    const tiles = L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
      maxZoom: 19,
      minZoom: 3,
      attribution: 'Map Data &copy; <a href="https://www.openstreetmap.org/">OpenStreetMap</a> contributors',
    }).addTo(MapaProfileComponent.map);
  }

  static mostrarMarcadorNoMapa(latitude: number, longitude: number) {
    // Remove o marcador anterior, se existir
    if (MapaProfileComponent.marker) {
      MapaProfileComponent.map.removeLayer(MapaProfileComponent.marker);
    }

    // Adiciona o novo marcador na posição selecionada
    MapaProfileComponent.marker = L.marker([latitude, longitude]).addTo(MapaProfileComponent.map);
  }

  static invalidateSize() {
    setTimeout(() => {
      MapaProfileComponent.map.invalidateSize();
    }, 500);
  }
}
