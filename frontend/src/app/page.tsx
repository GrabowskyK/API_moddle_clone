import { paths } from "@/paths";
import Link from "next/link";

export default function Home() {
  return (
    <main className="flex min-h-screen flex-col items-center justify-between p-24">
      <Link href={paths.signIn}>Sign in</Link>
      <Link href={paths.signUp}>Sign up</Link>
    </main>
  );
}
