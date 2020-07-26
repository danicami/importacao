import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ImportacaoComponent } from './importacao/importacao.component';
import { ImportacaoDetalheComponent } from './importacao-detalhe/importacao-detalhe.component';
import { ImportacaoNovoComponent } from './importacao-novo/importacao-novo.component';

const routes: Routes = [
  {
    path: 'importacao',
    component: ImportacaoComponent,
    data: { title: 'Lista de Importacao' }
  },
  {
    path: 'importacao-detalhe/:id',
    component: ImportacaoDetalheComponent,
    data: { title: 'Detalhe da Importação' }
  },
  {
    path: 'importacao-novo',
    component: ImportacaoNovoComponent,
    data: { title: 'Adicionar Importação' }
  },
  { path: '',
    redirectTo: '/importacao',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
