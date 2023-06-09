import { AfterViewInit, Component, EventEmitter, Output } from '@angular/core';
import * as L from 'leaflet';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.scss'],
})
export class MapComponent implements AfterViewInit {
  public static map: L.Map;
  private static marker: L.Marker;
  msgFromMapChild: any[];

  @Output() locationConfirmed: EventEmitter<any> = new EventEmitter<any>();

  constructor() {
    this.msgFromMapChild = [];
  }

  ngAfterViewInit(): void {
    this.initMapDefaultLeaflet();
    MapComponent.map.on('click', (ev) => {
      if (this.msgFromMapChild.length > 0) {
        this.msgFromMapChild.pop();
      }
      console.log(ev.latlng);
      this.locationConfirmed.emit(ev.latlng);

      // Remove o marcador anterior, se existir
      if (MapComponent.marker) {
        MapComponent.map.removeLayer(MapComponent.marker);
      }

      // Adiciona o novo marcador na posição selecionada
      MapComponent.marker = L.marker(ev.latlng).addTo(MapComponent.map);
    });
    MapComponent.invalidateSize();
  }

  private initMapDefaultLeaflet(): void {
    MapComponent.map = L.map('map-component').setView([41.169385019216094, -8.667400178166359], 15);
    const tiles = L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
      maxZoom: 19,
      minZoom: 3,
      attribution: 'Map Data &copy; <a href="https://www.openstreetmap.org/">OpenStreetMap</a> contributors',
    }).addTo(MapComponent.map);
  }

  static mostrarMarcadorNoMapa(latitude: number, longitude: number) {
    // Remove o marcador anterior, se existir
    if (MapComponent.marker) {
      MapComponent.map.removeLayer(MapComponent.marker);
    }

    // Adiciona o novo marcador na posição selecionada
    MapComponent.marker = L.marker([latitude, longitude]).addTo(MapComponent.map);
  }

  static invalidateSize() {
    setTimeout(() => {
      MapComponent.map.invalidateSize();
    }, 500);
  }
}
