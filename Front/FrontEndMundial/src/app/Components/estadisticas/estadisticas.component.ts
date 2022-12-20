import { Component } from '@angular/core';

import { Asistencia } from 'src/app/models/Asistencia';
import { Goleadores } from 'src/app/models/Goleadores';
import { TarjetaRoja } from 'src/app/models/TarjetaRoja';
import { AsistenciasService } from 'src/app/services/estadisticas/asistencias.service';
import { GoleadoresService } from 'src/app/services/estadisticas/goleadores.service';
import { TarjetasrojasService } from 'src/app/services/estadisticas/tarjetasrojas.service';

export interface PeriodicElement {
  Jugador: string;
  Goles: number;
}

@Component({
  selector: 'app-estadisticas',
  templateUrl: './estadisticas.component.html',
  styleUrls: ['./estadisticas.component.css'],
})
export class EstadisticasComponent {
  goleadores: Goleadores[] | undefined;
  asistencias: Asistencia[] | undefined;
  tarjetasrojas: TarjetaRoja[] | undefined;

  constructor(
    public goleadoresservice: GoleadoresService,
    public asistenciasservice: AsistenciasService,
    public tarjetasrojasservice: TarjetasrojasService
  ) {}

  ngOnInit() {}

  getDataGoleadores() {
    this.goleadoresservice.getGoleadores_2();
  }

  getDataAsistencias() {
    this.asistenciasservice.getAsistencias_2();
  }

  getDataTarjetasRojas() {
    this.tarjetasrojasservice.getTarjetasRojas_2();
  }
}
