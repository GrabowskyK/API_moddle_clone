import { Api } from "./api-client";

export const api = new Api({ baseURL: process.env.NEXT_PUBLIC_API_BASE_URL });
