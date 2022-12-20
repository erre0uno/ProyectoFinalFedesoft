import { Component, OnInit } from '@angular/core';

//imports
import { LoginService } from 'src/app/services/loginServices/login.service';
import { Router } from '@angular/router';
import {
  FormControl,
  FormGroupDirective,
  NgForm,
  Validators,
  FormBuilder,
  FormGroup,
} from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';
import Swal from 'sweetalert2';

export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(
    control: FormControl | null,
    form: FormGroupDirective | NgForm | null
  ): boolean {
    const isSubmitted = form && form.submitted;
    return !!(
      control &&
      control.invalid &&
      (control.dirty || control.touched || isSubmitted)
    );
  }
}

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  emailFormControl = new FormControl('', [Validators.required]);
  claveFormControl = new FormControl('', [Validators.required]);
  matcher = new MyErrorStateMatcher();
  fValidator: FormGroup = this.fb.group({
    nombre: ['', [Validators.required]],
    clave: ['', [Validators.required]],
  });

  constructor(
    private servicioLogin: LoginService,
    private router: Router,
    private fb: FormBuilder
  ) {}

  //variables del formulario
  nombre?: string = '';
  clave?: string = '';

  ngOnInit(): void {}

  errorLogin() {
    Swal.fire({
      icon: 'error',
      title: 'Datos Incorrectos',
      text:'Verifica los datos ingresados',
      showConfirmButton: false,
      timer: 2000,
    });
}
loginAlert() {
  Swal.fire({
    icon: 'success',
    title: 'Bienvenido',
    showConfirmButton: false,
    timer: 2000,
  });
}
  login() {
    var usuario = {
      id: 0,
      nombre: this.nombre,
      clave: this.clave,
      tipo: 'admin',
    };
    var response = this.servicioLogin.post(usuario).subscribe({
      next: (v) => {
        console.log(v);
        var response: any = v;
        this.servicioLogin.GuardarToken(response.token);
        this.loginAlert();
        setTimeout(()=>{
          this.router.navigate(['/inicio']);
        },2000)
        //metodo reload()
        //window.location.reload(forceGet)
      },
      error: (e) => {
        console.error(e);
        this.errorLogin();
      },

      complete: () => console.info('login completo'),
    });
  }
}
