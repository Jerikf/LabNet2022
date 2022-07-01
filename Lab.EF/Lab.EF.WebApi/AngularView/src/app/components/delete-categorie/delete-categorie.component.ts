import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Categorie } from 'src/app/models/Categorie';
import { CategorieService } from 'src/app/services/categorie.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-delete-categorie',
  templateUrl: './delete-categorie.component.html',
  styleUrls: ['./delete-categorie.component.css']
})
export class DeleteCategorieComponent implements OnInit {

  constructor(private categorieService :  CategorieService, private router: Router, private route:ActivatedRoute) { }

  name : string = '';
  description : string = "";
  id : number = 0;

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];
    let categorie : Categorie;
    this.categorieService.GetCategorie(this.id).subscribe(c =>{
      categorie = c;
      console.log(categorie);
      this.name = categorie.CategoryName;
      this.description = categorie.Description;
    });
  }

  Delete(){
    this.categorieService.DeleteCategorie(this.id).subscribe(data =>{
      alert("Se eliminó correctamente");
      console.log("User Delete" + data);
      location.href = environment.urlBase + 'list';
    }, (err) => {
      console.log("Unable to delete the Categorie" + err);
      alert("No se puede eliminar categorias que tienen relaciones con otras entidades");
      this.router.navigate(['/list']);
    });
    
    
  }

  Volver(){
    this.router.navigate(['/list']);
  }



}
