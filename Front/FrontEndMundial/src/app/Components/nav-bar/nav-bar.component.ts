import { Component, OnInit } from '@angular/core';

//imports
import { Subscription } from 'rxjs';
import { LoginService } from 'src/app/services/loginServices/login.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css'],
})
export class NavBarComponent implements OnInit {
  //implementacion

  //control sesion
  admin: boolean = false;
  subscripcion: Subscription = new Subscription();

  constructor(private servicioLogin: LoginService) {}

  ngOnInit(): void {
    this.subscripcion = this.servicioLogin
      .obtenerDatosUsuarioEnSesion()
      .subscribe((datos: any) => {
        if (datos) {
          this.admin = true;
        }
      });
  }

  logOut() {
    sessionStorage.removeItem('token');
    this.admin = false;
  }

  menuResponsive() {
    const elemento = document.querySelector('.button-responsive');
    const elemento2 = document.querySelector('.toolbar-responsive');
    if (elemento?.classList.contains('visible')) {
      elemento?.classList.remove('visible');
      elemento2?.classList.remove('visible');
    } else {
      elemento?.classList.add('visible');
      elemento2?.classList.add('visible');
    }
  }

  closeResponsive() {
    const elemento = document.querySelector('.button-responsive');
    const elemento2 = document.querySelector('.toolbar-responsive');

    elemento?.classList.remove('visible');
    elemento2?.classList.remove('visible');
  }
}
