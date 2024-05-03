export class Enums {
    static Role = {
        Admin: 1,
        PersonalUser: 2,
        OrganizationalUser: 3
    } as const;

    static ConnectionRequests = {
        NotConnected: 0,
        Accept: 1,
        Pending: 2
    } as const;
}
