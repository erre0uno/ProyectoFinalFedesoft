import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/app/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class JugadorService {
  url: string = environment.url;
  constructor(private httpclient: HttpClient) {}

  getJugador(): Observable<any[]> {
    return this.httpclient.get<any[]>(this.url + 'jugadores');
  }
}
