import { Component, OnInit } from '@angular/core';

//imports

import { Observable } from 'rxjs';
import { UsuariosService } from 'src/app/services/loginServices/usuarios.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-ver-usuarios',
  templateUrl: './ver-usuarios.component.html',
  styleUrls: ['./ver-usuarios.component.css'],
})
export class VerUsuariosComponent implements OnInit {
  ListUsuarios$!: Observable<any[]>;

  //modal
  title: string = '';
  modal: boolean = false;
  usuario: any;

  constructor(private servicioUsuario: UsuariosService) {}

  ngOnInit(): void {
    this.ListUsuarios$ = this.servicioUsuario.get();
    console.log(this.ListUsuarios$);
  }

  showAlertDelete() {
    Swal.fire({
      icon: 'success',
      title: 'Registro Eliminado correctamente',
      showConfirmButton: false,
      timer: 2000,
    });
  }

  modalAdd() {
    this.usuario = {
      id: 0,
      nombre: null,
      clave: null,
      tipo: null,
    };
    this.title = 'Agregar Usuario';
    this.modal = true;
  }

  modalEdit(item: any) {
    this.title = 'Editar Usuario';
    this.usuario = item;
    this.modal = true;
  }

  modalclose() {
    this.modal = false;
    this.ListUsuarios$ = this.servicioUsuario.get();
  }

  delete(item: any) {
    if (confirm(`Esta seguro de eliminar el registro  ${item.id}`)) {
      this.servicioUsuario.delete(item.id).subscribe(() => {
        this.showAlertDelete();
        this.ListUsuarios$ = this.servicioUsuario.get();
      });
    }
  }
}
