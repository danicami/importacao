import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ImportacaoApiService } from 'src/service/importacao-api.service';
import { Importacao } from 'src/model/importacao';
import { toDate } from '@angular/common/src/i18n/format_date';

@Component({
  selector: 'app-importacao-detalhe',
  templateUrl: './importacao-detalhe.component.html',
  styleUrls: ['./importacao-detalhe.component.scss']
})
export class ImportacaoDetalheComponent implements OnInit {
  importacao: Importacao = { id: 0, dataEntrega: '', nomeProduto: '', quantidade: 0, valorUnitario: 0, valorTotal: 0 };
  isLoadingResults = true;
  constructor(private router: Router, private route: ActivatedRoute, private api: ImportacaoApiService) { }

  ngOnInit() {
    this.getImportacao(this.route.snapshot.params['id']);
  }

  getImportacao(id) {
    this.api.getImportacao(id)
      .subscribe(data => {
        this.importacao = data;
        console.log(this.importacao);
        this.isLoadingResults = false;
      });
  }

  
}
