import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { AlertController } from '@ionic/angular';


@Component({
  selector: 'app-login',
  templateUrl: './login.page.html',
  styleUrls: ['./login.page.scss'],
})
export class LoginPage implements OnInit {
  email: string = '';
  password: string = '';

  constructor(
    private http: HttpClient,
    private router: Router,
    private alertController: AlertController
  ) {}

  fazerLogin(): void {
    const url = 'http://localhost/API_WebGeo/api/login';
    const body = { email: this.email, password: this.password };

    this.http.post(url, body).subscribe(
      () => {
        this.redirecionarParaMapa();
      },
      (error) => {
        console.error(error);
        this.exibirMensagemErro('Erro de login', 'As credenciais fornecidas estão incorretas.');
      }
    );
  }


  async redirecionarParaMapa(): Promise<void> {
    await this.router.navigate(['/map']);
  }

  async exibirMensagemErro(header: string, message: string): Promise<void> {
    const alert = await this.alertController.create({
      header,
      message,
      buttons: ['OK'],
    });
    await alert.present();
  }

  onSubmit(): void {
    this.fazerLogin();
  }

  ngOnInit() {}
}
