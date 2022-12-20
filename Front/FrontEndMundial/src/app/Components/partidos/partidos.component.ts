import { Component } from '@angular/core';
import { ResultadoService } from 'src/app/services/resultadoServicio/resultado.service';
import { Resultado } from 'src/app/models/resultado';
import { Subscription } from 'rxjs';
import { LoginService } from 'src/app/services/loginServices/login.service';

@Component({
  selector: 'app-partidos',
  templateUrl: './partidos.component.html',
  styleUrls: ['./partidos.component.css'],
})
export class PartidosComponent {
  admin: boolean = false;
  subscripcion: Subscription = new Subscription();
  ResultadoList!: Resultado[];
  numero!: Resultado['numeroPartido'];
  EquipoList: any = [];
  EquipoMap: Map<number, string> = new Map();

  constructor(
    public serviceResultado: ResultadoService,
    private servicioLogin: LoginService
  ) {}

  ngOnInit() {
    //this.ResultadoList$ = this.serviceResultado.getResultado();
    this.serviceResultado.obtenerResultado2();
    this.subscripcion = this.servicioLogin
      .obtenerDatosUsuarioEnSesion()
      .subscribe((datos: any) => {
        if (datos) {
          this.admin = true;
        }
      });
  }
}
