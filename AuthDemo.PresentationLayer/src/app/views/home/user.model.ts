export class User{
  constructor(
    public Id: number,
    public Name: string,
    public Email: string,
    public Password: string,
    public RoleDescription: string | null,
    public Role: number,

  ){
  }
}
