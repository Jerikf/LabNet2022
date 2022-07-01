import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { ListCategorieComponent } from './components/list-categorie/list-categorie.component';
import { CreteCategorieComponent } from './components/crete-categorie/crete-categorie.component';
import { HomeComponent } from './components/home/home.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { RouterModule, Routes } from '@angular/router';
import { CategorieService } from './services/categorie.service';
import { HttpClientModule } from '@angular/common/http';
import { DeleteCategorieComponent } from './components/delete-categorie/delete-categorie.component';
import { UpdateCategorieComponent } from './components/update-categorie/update-categorie.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

const appRoute:Routes = [
  {path:'', component:HomeComponent},
  {path:'list', component:ListCategorieComponent},
  {path:'update/:id', component: UpdateCategorieComponent},
  {path:'delete/:id', component: DeleteCategorieComponent},
  {path: 'create', component: CreteCategorieComponent}
];

@NgModule({
  declarations: [
    AppComponent,
    ListCategorieComponent,
    CreteCategorieComponent,
    HomeComponent,
    NavbarComponent,
    DeleteCategorieComponent,
    UpdateCategorieComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(appRoute),
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [CategorieService],
  bootstrap: [AppComponent]
})
export class AppModule { }
