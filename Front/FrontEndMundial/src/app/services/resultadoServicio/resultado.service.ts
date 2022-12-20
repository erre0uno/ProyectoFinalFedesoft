import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Resultado } from 'src/app/models/resultado';
import { Observable } from 'rxjs';
import { environment } from 'src/app/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class ResultadoService {
  url = environment.url;

  listaResultados!: Resultado[];

  constructor(private http: HttpClient) {}

  obtenerResultado2() {
    this.http
      .get(this.url + 'resultados')
      .toPromise()
      .then((data) => {
        this.listaResultados = data as Resultado[];
      });
  }

  getHttpOptions() {
    const httpOptions = {
      headers: new HttpHeaders({
        Authorization: 'Bearer ' + sessionStorage.getItem('token'),
      }),
    };
    return httpOptions;
  }

  async obtenerResultado() {
    await this.http
      .get(this.url + 'resultados')
      .toPromise()
      .then((data) => {
        this.listaResultados = data as Resultado[];
      });
    return this.listaResultados;
  }

  actualizarResultados(
    id: number,
    resultado: Resultado
  ): Observable<Resultado> {
    return this.http.put<Resultado>(
      this.url + 'resultados/' + id,
      resultado,
      this.getHttpOptions()
    );
  }
}
