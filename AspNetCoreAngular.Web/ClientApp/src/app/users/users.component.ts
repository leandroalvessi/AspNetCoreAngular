import { Component, OnInit } from '@angular/core';
import { UserDataService } from '../_data-services/user.data-service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  users: any[] = [];
  user: any = {};
  showList: boolean = true;

  constructor(private userDataService: UserDataService) { }

  ngOnInit() {
    this.get();
  }

  get() {
    this.userDataService.get().subscribe((data: any[]) => {
      this.users = data;
      this.showList = true;
    }, error => {
      console.log(error);
      alert('erro interno do sistema');
    })
  }

  save() {
    debugger;
    if (this.user.id) {
      this.put();
    } else {
      this.post();
    }
  }

  openDetails(user) {
    this.showList = false;
    this.user = user;
  }

  put() {
    this.userDataService.put(this.user).subscribe(data => {
      if (data) {
        alert('Usuario atualizado com sucesso');
        this.get();
        this.user = {};
      } else {
        alert('Erro ao cadastrar usuario');
      }
    }, error => {
      console.log(error);
      alert('erro interno do sistema');
    })
  }

  post() {
    this.userDataService.post(this.user).subscribe(data => {
      if (data) {
        alert('Usuario cadastrado com sucesso');
        this.get();
        this.user = {};
      } else {
        alert('Erro ao cadastrar usuario');
      }
    }, error => {
      console.log(error);
      alert('erro interno do sistema');
    })
  }

}

