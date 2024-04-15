export class Message {
    chatId?: number;
    messageContent!: string;
    receiverId?: number;
    isRead!: boolean;
    senderId?: number;
    timestamp?: Date;
    firstName?: string;
    lastName?: string;
    profileImage?: Uint8Array;
    sentByMe!: boolean;
}