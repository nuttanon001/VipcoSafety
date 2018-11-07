// Angular Core
import { NgModule } from '@angular/core';
import { HttpModule } from "@angular/http";
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
// Components
import { AppComponent } from './core/app/app.component';
import { HomeComponent } from './core/home/home.component';
import { NavMenuComponent } from './core/nav-menu/nav-menu.component';
import { LoginComponent } from './users/login/login.component';
import { RegisterComponent } from './users/register/register.component';
// Services
import { ShareService } from './shared/share.service';
import { AuthService } from './core/auth/auth.service';
import { MessageService } from './shared/message.service';
import { AuthGuard } from './core/auth/auth-guard.service';
import { HttpErrorHandler } from './shared/http-error-handler.service';
import { DialogsModule } from './dialogs/dialog.module';
import { CustomMaterialModule } from './shared/customer-material.module';
import { SharedModule } from "./shared/shared.module";

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavMenuComponent,
    LoginComponent,
    RegisterComponent,
  ],
  imports: [
    // Angular Core
    HttpModule,
    FormsModule,
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    // Modules
    // SharedModule,
    DialogsModule,
    CustomMaterialModule,
    RouterModule.forRoot([
      { path: "", redirectTo: "home", pathMatch: "full" },
      { path: "home", component: HomeComponent },
      { path: "login", component: LoginComponent },
      { path: "register/:condition", component: RegisterComponent },
      { path: "register", component: RegisterComponent },
      {
        path: "employee",
        loadChildren: "./employees/employee.module#EmployeeModule",
        canActivate: [AuthGuard]
      },
      {
        path: "approved-flows",
        loadChildren: "./approved-flows/approved-flow.module#ApprovedFlowModule",
        canActivate: [AuthGuard]
      },
      {
        path: "confined-space",
        loadChildren: "./confined-spaces/confined-space.module#ConfinedSpaceModule",
        canActivate: [AuthGuard]
      },
      {
        path: "lifting",
        loadChildren: "./liftings/lifting.module#LiftingModule",
        canActivate: [AuthGuard]
      },
      {
        path: "groupwork-permits",
        loadChildren: "./groupwork-permits/groupwork-permit.module#GroupworkPermitModule",
        canActivate: [AuthGuard]
      },
      {
        path: "work-permits",
        loadChildren: "./all-work-permits/all-work-permit.module#AllWorkPermitModule",
        canActivate: [AuthGuard]
      },
      {
        path: "safety-mail",
        loadChildren: "./safeties/safety.module#SafetyModule",
        canActivate: [AuthGuard],
      },
      {
        path: "user",
        loadChildren: "./users/userid.module#UseridModule",
        canActivate: [AuthGuard]
      },
      { path: "**", redirectTo: "home" },
    ])
  ],
  providers: [
    AuthGuard,
    AuthService,
    MessageService,
    HttpErrorHandler
  ],
  bootstrap: [
    AppComponent
  ]
})
export class AppModule { }
