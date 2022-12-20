import { Component } from '@angular/core';
import { TablaPosicionesService } from 'src/app/services/tablaPosiciones/tabla-posiciones.service';
import { ResultadoService } from 'src/app/services/resultadoServicio/resultado.service';
import { Subscription } from 'rxjs';
import { LoginService } from 'src/app/services/loginServices/login.service';

@Component({
  selector: 'app-posiciones',
  templateUrl: './posiciones.component.html',
  styleUrls: ['./posiciones.component.css'],
})
export class PosicionesComponent {
  admin: boolean = false;
  subscripcion: Subscription = new Subscription();
  contador: number = 0;
  infoResultado: any = [];
  partidosQatar: any = [];
  partidosEcuador: any = [];
  partidosSenegal: any = [];
  partidosPaisesBajo: any = [];
  partidosInglaterra: any = [];
  partidosGales: any = [];
  partidosIran: any = [];
  partidosEEUU: any = [];

  constructor(
    public tablaPosicionesServices: TablaPosicionesService,
    public resultadoServicio: ResultadoService,
    private servicioLogin: LoginService
  ) {}


  async ngOnInit() {
    this.tablaPosicionesServices.obtenerPosiciones();

    await Promise.resolve(this.resultadoServicio.obtenerResultado()).then(
      (data) => {
        this.infoResultado = data;
      }
    );
    await this.seccionarPartidos(this.infoResultado);

    this.subscripcion = this.servicioLogin
      .obtenerDatosUsuarioEnSesion()
      .subscribe((datos: any) => {
        if (datos) {
          this.admin = true;
        }
      });
  }

  seccionarPartidos(infoResultado: any) {
    this.partidosQatar = infoResultado.filter((partidos: any) => {
      return partidos.equipoId === 1;
    });
    this.partidosEcuador = infoResultado.filter((partidos: any) => {
      return partidos.equipoId === 2;
    });
    this.partidosSenegal = infoResultado.filter((partidos: any) => {
      return partidos.equipoId === 3;
    });
    this.partidosPaisesBajo = infoResultado.filter((partidos: any) => {
      return partidos.equipoId === 4;
    });
    this.partidosInglaterra = infoResultado.filter((partidos: any) => {
      return partidos.equipoId === 5;
    });

    this.partidosGales = infoResultado.filter((partidos: any) => {
      return partidos.equipoId === 6;
    });

    this.partidosIran = infoResultado.filter((partidos: any) => {
      return partidos.equipoId === 7;
    });

    this.partidosEEUU = infoResultado.filter((partidos: any) => {
      return partidos.equipoId === 8;
    });
  }
}
