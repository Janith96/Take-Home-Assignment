import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { UserStoreService } from 'src/app/services/user-store.service';

@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.css']
})
export class AdminDashboardComponent implements OnInit {
  public role! : string;

  constructor(private auth: AuthService, private userStore: UserStoreService) { }

  ngOnInit(): void {
    this.userStore.getRoleFromStore()
      .subscribe(value => {
       let roleFromToken = this.auth.getRoleFromToken();
       this.role = value || roleFromToken;
      })
  }

  logout(){
    this.auth.signOut();
  }

}
