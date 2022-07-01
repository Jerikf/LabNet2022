import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { RickAnMory } from '../models/RickAndMorty';
import { Categorie } from '../models/Categorie';
@Injectable({
  providedIn: 'root'
})
export class CategorieService {
  endpoint : string = 'Categories';


  constructor(private http: HttpClient) {}

  public GetCharacters(): Observable<Array<any>>{
    return this.http.get<Array<any>>(environment.urlBaseApi + this.endpoint);
  }

  public CreateCategorie(categorie : Categorie): Observable<any>{

    return this.http.post(environment.urlBaseApi + this.endpoint, categorie);
  }

  public DeleteCategorie(id : number): Observable<any>{
    return this.http.delete(environment.urlBaseApi + this.endpoint + '/' + id);
  }

  public UpdateCategorie(categorie : Categorie): Observable<any>{
    return this.http.patch(environment.urlBaseApi + this.endpoint, categorie);
  }

  public GetCategorie(id: number): Observable<Categorie>{
    return this.http.get<any>(environment.urlBaseApi + this.endpoint + '/' + id);
  }

}
