import { Injectable } from '@angular/core';

//imports
import {
  HttpClient,
  HttpHeaders,
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/app/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class UsuariosService {
  //Header de peticiones
  getHttpOptions() {
    const httpOptions = {
      headers: new HttpHeaders({
        Authorization: 'Bearer ' + sessionStorage.getItem('token'),
      }),
    };
    return httpOptions;
  }

  //readonly url = 'https://localhost:44335/api/';
  url: string = environment.url;

  constructor(private http: HttpClient) {}

  //metodos
  public get(): Observable<any[]> {
    return this.http.get<any>(this.url + 'usuarios', this.getHttpOptions());
  }

  //getId
  public getId(id: number | string): Observable<any> {
    return this.http.get<any>(
      this.url + 'usuarios/' + id,
      this.getHttpOptions()
    );
  }
  //post
  public post(data: any) {
    return this.http.post(this.url + 'usuarios', data, this.getHttpOptions());
  }
  //put

  public put(id: number | string, data: any) {
    return this.http.put(
      this.url + 'usuarios/' + id,
      data,
      this.getHttpOptions()
    );
  }

  //delete
  public delete(id: number | string) {
    return this.http.delete(this.url + 'usuarios/' + id, this.getHttpOptions());
  }
}
