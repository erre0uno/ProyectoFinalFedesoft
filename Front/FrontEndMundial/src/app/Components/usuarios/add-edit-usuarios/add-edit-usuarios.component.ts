import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

//imports
import { Observable } from 'rxjs';
import { UsuariosService } from 'src/app/services/loginServices/usuarios.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-add-edit-usuarios',
  templateUrl: './add-edit-usuarios.component.html',
  styleUrls: ['./add-edit-usuarios.component.css'],
})
export class AddEditUsuariosComponent implements OnInit {
 
  ListUsuarios$!: Observable<any[]>;
  @Input() usuario: any;
  id?: number = 0;
  nombre?: string = '';
  clave?: string = '';
  fValidator: FormGroup = this.fb.group({
    nombre: ['', [Validators.required]],
    clave: ['', [Validators.required]],
    id: [''],
  });

  constructor(
    private servicioUsuario: UsuariosService,
    private fb: FormBuilder
  ) {}


  ngOnInit(): void {
    this.id = this.usuario.id;
    this.nombre = this.usuario.nombre;
    this.ListUsuarios$ = this.servicioUsuario.get();
  }

  showAlert() {
    Swal.fire({
      icon: 'success',
      title: 'Registro creado correctamente',
      showConfirmButton: false,
      timer: 2000,
    });
  }

  showAlertUpdate() {
    Swal.fire({
      icon: 'success',
      title: 'Registro actualizado correctamente',
      showConfirmButton: false,
      timer: 2000,
    });
  }

  agregarUsuario() {
    var usuario = {
      nombre: this.nombre,
      clave: this.clave,
      tipo: 'admin',
    };
    this.servicioUsuario.post(usuario).subscribe((res) => {
      this.showAlert();
      var closeModal = document.getElementById('add-edit-modal-close');
      if (closeModal) {
        closeModal.click();
      }
    });
  }

  updateUsuario() {
    var usuario = {
      id: this.id,
      nombre: this.nombre,
      clave: this.clave,
      tipo: 'admin',
    };
    let a: any = this.id;
    let id: number = Number(a);
    this.servicioUsuario.put(id, usuario).subscribe((res) => {
      this.showAlertUpdate();
      var closeModal = document.getElementById('add-edit-modal-close');
      if (closeModal) {
        closeModal.click();
      }
    });
  }
}
