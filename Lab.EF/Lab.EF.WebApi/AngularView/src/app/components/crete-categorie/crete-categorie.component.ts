import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Categorie } from 'src/app/models/Categorie';
import { CategorieService } from 'src/app/services/categorie.service';

@Component({
  selector: 'app-crete-categorie',
  templateUrl: './crete-categorie.component.html',
  styleUrls: ['./crete-categorie.component.css']
})
export class CreteCategorieComponent implements OnInit {

  

  constructor(private formBuilder : FormBuilder, private categorieService : CategorieService, private router : Router) {
    this.form = this.formBuilder.group({
      name: ['',Validators.required],
      description: ['', Validators.required]
    });
   }

  form : FormGroup;

  ngOnInit(): void {}

  OnSubmit(){
    let newCategorie = new Categorie();
    newCategorie.CategoryName = this.form.get('name')?.value;
    newCategorie.Description = this.form.get('description')?.value;

    this.categorieService.CreateCategorie(newCategorie).subscribe((res) =>{
      this.form.reset();
      console.log("Se creo correctamente");
      alert("Se creo correctamente la Categoria");
    }, (err) => {
      console.log("No se pudo crear");
      alert("Ups!--> no se pudo crear la Categoria, fijese por favor los datos sean los correctos");
    })
    this.router.navigate(['/list']);
   // console.log(this.form.value);
  }

  Volver(){
    this.router.navigate(['/list']);
  }



}
