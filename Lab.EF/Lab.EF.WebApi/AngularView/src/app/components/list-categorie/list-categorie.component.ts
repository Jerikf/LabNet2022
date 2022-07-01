import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { Categorie } from 'src/app/models/Categorie';
import { RickAnMory } from 'src/app/models/RickAndMorty';
import { CategorieService } from 'src/app/services/categorie.service';

@Component({
  selector: 'app-list-categorie',
  templateUrl: './list-categorie.component.html',
  styleUrls: ['./list-categorie.component.css']
})
export class ListCategorieComponent implements OnInit {

  constructor(private categorieService : CategorieService) { }
  private charactersObs? : Subscription;
  public characters?:Array<any>;

  ngOnInit(): void {
    /*
    this.charactersObs = this.categorieService
      .GetCharacters()
      .subscribe((res) => {
        this.characters = res;
        this.characters = this.characters['results'];
        console.log(this.characters);
      });*/

      this.charactersObs = this.categorieService
      .GetCharacters()
      .subscribe((res) => {
        this.characters = res;
        console.log(this.characters);
      });

  }


  mostrar(){
    //console.log(this.characters['results']);
   
  }
/*
  mostrar(){
    console.log("hi");
  }*/
}
