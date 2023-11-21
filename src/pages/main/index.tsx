import { useEffect, useState } from "react";
import { MainLayout, RestarauntsList } from "@/components";
import { RestarauntsResponse } from "@/models";
import { Constants } from "@/types";
import CircularProgress from "@mui/material/CircularProgress";

export const MainPage = () => {
  const [loading, setLoading] = useState(true);
  const [currentPage, setCurrentPage] = useState(1);
  const [data, setData] = useState<RestarauntsResponse | null>(null);

  useEffect(() => {
    async function getData() {
      setLoading(true);
      const response = (await fetch(
        `${Constants.BASE_URL}/user/listrest?page=${currentPage}&limit=5`
      ).then((res) => res.json())) as RestarauntsResponse;

      setData(response);
      setLoading(false);
    }

    getData();
  }, [currentPage]);

  console.log({ data });

  return (
    <MainLayout>
      {loading && <CircularProgress />}
      <RestarauntsList
        currentPage={currentPage}
        items={data?.data || []}
        totalCount={data?.count || 0}
        setCurrentPage={setCurrentPage}
      />
    </MainLayout>
  );
};
