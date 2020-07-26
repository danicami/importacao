import { Component, OnInit } from '@angular/core';
import { ImportacaoApiService } from 'src/service/importacao-api.service';
import { Importacao } from 'src/model/importacao';

@Component({
  selector: 'app-importacao',
  templateUrl: './importacao.component.html',
  styleUrls: ['./importacao.component.scss']
})


export class ImportacaoComponent implements OnInit {

  displayedColumns: string[] = ['indentificador', 'dataEntrega', 'nomeProduto', 'quantidade', 'valorUnitario', 'valorTotal', 'id'];
  dataSource: Importacao[];
  
  constructor(private _api: ImportacaoApiService) { }

  ngOnInit() {
    this._api.getImportacoes()
      .subscribe(res => {
        this.dataSource = res;
        console.log(this.dataSource);
       // this.isLoadingResults = false;
      }, err => {
        console.log(err);
      //  this.isLoadingResults = false;
      });
  }
}
