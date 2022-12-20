import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/app/environments/environment';
import { Asistencia } from 'src/app/models/Asistencia';

@Injectable({
  providedIn: 'root',
})
export class AsistenciasService {
  url = environment.url;
  asistencias!: Asistencia[];
  constructor(private httpclient: HttpClient) {}

  getHttpOptions() {
    const httpOptions = {
      headers: new HttpHeaders({
        Authorization: 'Bearer ' + sessionStorage.getItem('token'),
      }),
    };
    return httpOptions;
  }

  getAsistencias(): Observable<Asistencia[]> {
    return this.httpclient.get<Asistencia[]>(this.url + 'asistencias');
  }

  getAsistencias_2() {
    this.httpclient
      .get(this.url + 'asistencias/')
      .toPromise()
      .then((data) => {
        this.asistencias = data as Asistencia[];

        this.asistencias?.sort((a, b) =>
          a.asistencias < b.asistencias ? 1 : -1
        );
      });
  }

  updateAsistencias(id: number, posicion: Asistencia): Observable<Asistencia> {
    return this.httpclient.put<Asistencia>(
      this.url + 'asistencias/' + id,
      posicion,
      this.getHttpOptions()
    );
  }
}
