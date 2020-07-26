import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ImportacaoApiService } from 'src/service/importacao-api.service';
import { FormGroup, FormControl, NgForm, Validators } from '@angular/forms';

@Component({
  selector: 'app-importacao-novo',
  templateUrl: './importacao-novo.component.html',
  styleUrls: ['./importacao-novo.component.scss']
})

export class ImportacaoNovoComponent implements OnInit {

  importacaoForm: FormGroup;
  isLoadingResults = false;

  constructor(private router: Router, private route: ActivatedRoute, private api: ImportacaoApiService) { }

  ngOnInit() {
    this.importacaoForm = new FormGroup({
      anexos: new FormControl()
    });
  }

  onSubmit() {
    let file = new FormData();
    file.append("file", this.importacaoForm.controls.anexos.value.files[0])
    this.api.sendFile(file).subscribe(res => {
      // mostra no log o ultimo registro passado pelo excel
      console.log(res)
    });
    this.router.navigate(['/importacao']);
  }
}
