"use client";
import { Button } from "@/components/ui/button";
import {
  Card,
  CardContent,
  CardFooter,
  CardHeader,
} from "@/components/ui/card";
import { Form } from "@/components/ui/form";
import { useForm } from "react-hook-form";

interface pageProps {}

const page = (props: pageProps) => {
  const formProps = useForm({});

  return (
    <Card className="w-[500px]">
      <CardHeader>Create new account</CardHeader>
      <CardContent>
        <Form>
          <form></form>
        </Form>
      </CardContent>
      <CardFooter>
        <Button></Button>
      </CardFooter>
    </Card>
  );
};

export default page;
