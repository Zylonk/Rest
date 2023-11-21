import { Header } from "@/components";
import { FC, ReactNode } from "react";

type MainLayoutProps = {
  children: ReactNode;
};

export const MainLayout: FC<MainLayoutProps> = ({ children }) => {
  return (
    <>
      <Header />

      <main>{children}</main>
    </>
  );
};
