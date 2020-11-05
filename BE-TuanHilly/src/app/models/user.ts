import { Role } from "./role";
export class User {
    id: number;
    matkhau: string;
    taikhoan: string;
    hoten: string;
    role: Role;

    token?: string;
}
