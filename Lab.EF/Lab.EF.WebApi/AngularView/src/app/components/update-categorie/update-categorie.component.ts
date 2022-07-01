import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Categorie } from 'src/app/models/Categorie';
import { CategorieService } from 'src/app/services/categorie.service';

@Component({
  selector: 'app-update-categorie',
  templateUrl: './update-categorie.component.html',
  styleUrls: ['./update-categorie.component.css']
})
export class UpdateCategorieComponent implements OnInit {

  constructor(private categorieService :  CategorieService, private router: Router, private route:ActivatedRoute, private formBuilder : FormBuilder) { 
    this.form = this.formBuilder.group({
      name: ['',Validators.required],
      description: ['', Validators.required]
    });
  }

  form : FormGroup;
  name : string = '';
  description : string = "";
  id : number = 0;
  idMostrar? : number;
  
  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];
    let categorie : Categorie;
    this.categorieService.GetCategorie(this.id).subscribe(c =>{
      categorie = c;
      this.name = categorie.CategoryName;
      this.description = categorie.Description;
    });
  }

  OnSubmit(){
    let newCategorie = new Categorie();
    newCategorie.CategoryID = this.id;  
    newCategorie.CategoryName = this.form.get('name')?.value;
    newCategorie.Description = this.form.get('description')?.value;
    this.categorieService.UpdateCategorie(newCategorie).subscribe((res) =>{
      this.form.reset();
      alert("Se Actualizó correctamente");
      console.log("Se Actualizó correctamente");
    }, (err) => {
      console.log("No se pudo Actualizar");
      alert("Hubo problemas : ups");
    })
    this.router.navigate(['/list']);
    console.log(this.form.value);



  }
  Volver(){
    this.router.navigate(['/list'])
  }

}
