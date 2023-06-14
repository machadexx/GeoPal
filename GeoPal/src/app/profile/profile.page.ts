import { Component, OnInit } from '@angular/core';
import { ProfileServiceService } from './profile-service.service';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { AlertController } from '@ionic/angular';
import { ChangeDetectorRef } from '@angular/core';
import { MapaProfileComponent } from '../mapa-profile/mapa-profile.component';
import * as L from 'leaflet';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.page.html',
  styleUrls: ['./profile.page.scss'],
})
export class ProfilePage implements OnInit {
  userProfile: any;
  marker: any;

  constructor(
    private profileService: ProfileServiceService,
    private router: Router,
    private http: HttpClient,
    private alertController: AlertController,
    private changeDetectorRef: ChangeDetectorRef
  ) {}

  sair() {
    localStorage.removeItem('email');
    localStorage.removeItem('password');

    this.router.navigateByUrl('/home');
  }

  get localizacao(): string {
    if (
      this.userProfile &&
      this.userProfile.Coordenadas_latitude === null &&
      this.userProfile.Coordenadas_longitude === null
    ) {
      return 'Sem dados.';
    } else {
      return `${this.userProfile.Coordenadas_latitude}, ${this.userProfile.Coordenadas_longitude}`;
    }
  }

  async eliminarConta() {
    const userId = this.userProfile.UtilizadorID;
    const apiUrl = `http://localhost/API_WebGeo/api/delete/${userId}`;

    // Cria o alerta de confirmação
    const confirmarExclusao = await this.alertController.create({
      header: 'Confirmar Exclusão',
      message: 'Tem certeza de que deseja excluir sua conta?',
      buttons: [
        {
          text: 'Cancelar',
          role: 'cancel',
          cssClass: 'secondary',
          handler: () => {
            console.log('A exclusão da conta foi cancelada.');
          },
        },
        {
          text: 'OK',
          handler: () => {
            // O user confirmou a exclusão, envia a solicitação DELETE para a API
            this.http.delete(apiUrl).subscribe(
              () => {
                // A conta do utilizador foi eliminada com sucesso
                console.log('Sua conta foi excluída com sucesso!');
                window.location.href = '/home';
              },
              (error) => {
                console.error(error);
                console.log('Ocorreu um erro ao excluir a conta. Por favor, tente novamente mais tarde.');
              }
            );
          },
        },
      ],
    });

    // Exibe o alerta de confirmação
    await confirmarExclusao.present();
  }

  async confirmarLocalizacao(coordenadas: any) {
    const latitude = coordenadas.lat;
    const longitude = coordenadas.lng;

    const confirmarCoordenadas = await this.alertController.create({
      header: 'Confirmar Coordenadas',
      message: `Confirma que estas são as suas coordenadas? (${latitude.toFixed(2)}, ${longitude.toFixed(2)})`,
      buttons: [
        {
          text: 'Cancelar',
          role: 'cancel',
          cssClass: 'secondary',
          handler: () => {
            console.log('As coordenadas não foram confirmadas.');
          },
        },
        {
          text: 'OK',
          handler: () => {
            this.atualizarCoordenadas(latitude, longitude);
            this.adicionarMarcadorNoMapa(coordenadas);
          },
        },
      ],
    });

    await confirmarCoordenadas.present();
  }

  private adicionarMarcadorNoMapa(coordenadas: any) {
    if (this.marker) {
      MapaProfileComponent.map.removeLayer(this.marker);
    }

    this.marker = L.marker(coordenadas).addTo(MapaProfileComponent.map);
  }

  async atualizarCoordenadas(latitude: number, longitude: number) {
    const userId = this.userProfile.UtilizadorID;
    const apiUrl = `http://localhost/API_WebGeo/api/update/${userId}`;

    const roundedLatitude = latitude.toFixed(2); // Arredonda a latitude para 2 casas decimais
    const roundedLongitude = longitude.toFixed(2); // Arredonda a longitude para 2 casas decimais

    const payload = {
      Coordenadas_latitude: roundedLatitude,
      Coordenadas_longitude: roundedLongitude,
    };

    this.http.put(apiUrl, payload).subscribe(
      () => {
        console.log('As coordenadas foram atualizadas com sucesso!');

        // Atualiza as coordenadas no objeto userProfile
        this.userProfile.Coordenadas_latitude = roundedLatitude;
        this.userProfile.Coordenadas_longitude = roundedLongitude;

        // Atualiza a página
        this.changeDetectorRef.detectChanges();
      },
      (error) => {
        console.error(error);
        console.log('Ocorreu um erro ao atualizar as coordenadas.');
      }
    );
  }

  ngOnInit() {
    this.loadUserProfile();
  }

  async loadUserProfile() {
    try {
      this.userProfile = await this.profileService.getUserProfile();
      if (this.userProfile && this.userProfile.Coordenadas_latitude !== null && this.userProfile.Coordenadas_longitude !== null) {
        const latitude = parseFloat(this.userProfile.Coordenadas_latitude);
        const longitude = parseFloat(this.userProfile.Coordenadas_longitude);
        MapaProfileComponent.mostrarMarcadorNoMapa(latitude, longitude);
      }
    } catch (error) {
      console.error(error);
    }
  }
}
