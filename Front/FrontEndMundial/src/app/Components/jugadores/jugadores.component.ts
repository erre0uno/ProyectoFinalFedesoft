import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { JugadorService } from 'src/app/services/jugadores/jugador.service';

@Component({
  selector: 'app-jugadores',
  templateUrl: './jugadores.component.html',
  styleUrls: ['./jugadores.component.css'],
})
export class JugadoresComponent {
  JugadorList$!: Observable<any[]>;
  listaNumeroRandom: any = [];
  numeroRandom: number = 0;

  constructor(private serviceJugador: JugadorService) {}

  ngOnInit() {
    this.JugadorList$ = this.serviceJugador.getJugador();

    let min = 0;
    let max = 100;
    let rept = 0;
    let end = 0;

    while (rept != -1) {
      for (let i = 0; i <= 30; i++) {
        this.numeroRandom = Math.round(Math.random() * (max - min) + min);

        if (
          this.listaNumeroRandom.indexOf(this.numeroRandom) < 0 &&
          this.numeroRandom != 0
        ) {
          this.listaNumeroRandom.push(this.numeroRandom);
        }

        end++;
        //this.listaNumeroRandom.count() === 20 ? (rept = -1) : false;
        end === 20 ? (rept = -1) : false;
      }
    }
  }
}
