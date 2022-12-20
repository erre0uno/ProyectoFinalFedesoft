import { Component } from '@angular/core';
import { Resultado } from 'src/app/models/resultado';
import { ResultadoService } from 'src/app/services/resultadoServicio/resultado.service';
import Swal from 'sweetalert2';


@Component({
  selector: 'app-form-update-partidos',
  templateUrl: './form-update-partidos.component.html',
  styleUrls: ['./form-update-partidos.component.css']
})
export class FormUpdatePartidosComponent {
  opcionSeleccionado: string = '0' // Iniciamos
  opcion: string = ''
  resultados: any = []

  infoSeleccionada:any
  id:number = 0;
  gf:number = 0
  gc:number = 0
  numeroPartido:number = 0
  equipoId:number = 0
  nombreEquipo:string = ''

  constructor(public resultadoService: ResultadoService){
  }

  ngOnInit() {
    this.resultadoService.obtenerResultado()
  }

  capturar() {
    this.opcion = this.opcionSeleccionado
  }
  errorOpcion() {
    Swal.fire({
      icon: 'error',
      title: 'No se pudo seleccionar un equipo',
      showConfirmButton: false,
      timer: 2000,
    });
}
showAlert() {
  Swal.fire({
    icon: 'success',
    title: 'Registro actualizado correctamente',
    text:'Recuerda Actualizar el otro equipo',
    showConfirmButton: false,
    timer: 2000,
  });
}
llenarDatosAlert() {
  Swal.fire({
    icon: 'error',
    title: 'Error al actualizar los datos',
    showConfirmButton: false,
    timer: 2000,
  });
}

  editar(resultado:any){
    if (this.opcion==='0') {
      this.errorOpcion()
    this.nombreEquipo = ''
    this.id = 0
    this.gf = 0
    this.gc = 0
    this.numeroPartido =0
    this.equipoId = 0
    }else{
    const resu = resultado
    this.infoSeleccionada = (resu[parseInt(this.opcion)-1])
    console.log(this.infoSeleccionada)

    this.nombreEquipo = this.infoSeleccionada.nombreEquipo
    this.id = this.infoSeleccionada.id
    this.gf = this.infoSeleccionada.gf
    this.gc = this.infoSeleccionada.gc
    this.numeroPartido = this.infoSeleccionada.numeroPartido
    this.equipoId = this.infoSeleccionada.equipoId
  }
  }



  limpiarFormulario() {
    this.opcionSeleccionado ='0'
    this.nombreEquipo = '';
    this.id = 0
    this.gf = 0
    this.gc = 0
    this.numeroPartido = 0 
    this.equipoId = 0
  }



  enviarInfo(){

    let obj:Resultado = {
      id:this.id,
      gf:this.gf,
      gc:this.gc,
      numeroPartido:this.numeroPartido, 
      equipoId:this.equipoId,
      nombreEquipo: this.nombreEquipo
    }
    if (
      obj.id === 0
    ) {
      this.llenarDatosAlert();
    } else { 
    this.resultadoService.actualizarResultados(this.id, obj).subscribe((data) => {
      this.resultadoService.obtenerResultado()
      this.showAlert()
      this.limpiarFormulario()
      console.log("Se actualizo")
    })
  }
  }

}
