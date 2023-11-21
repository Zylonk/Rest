import { FC, useCallback, Dispatch, SetStateAction } from "react";

import {
  Card,
  Pagination,
  CardHeader,
  CardContent,
  Typography,
  Button,
} from "@mui/material";
import { IRestaraunt } from "@/models";
import { useNavigate } from "react-router-dom";
import cl from "./style.module.scss";

type RestarauntsListProps = {
  items: IRestaraunt[];
  totalCount: number;
  currentPage: number;
  setCurrentPage: Dispatch<SetStateAction<number>>;
};

const limit = 5;

export const RestarauntsList: FC<RestarauntsListProps> = ({
  items,
  totalCount,
  currentPage,
  setCurrentPage,
}) => {
  const navigate = useNavigate();

  const pageCount = Math.ceil(totalCount / limit);

  const onPageChange = useCallback(
    (_: unknown, next: number) => setCurrentPage(next),
    [setCurrentPage]
  );

  return (
    <section className={cl.list}>
      <div className="container">
        <div className={cl.items}>
          {items.map((item) => (
            <Card key={item.restaurantId}>
              <CardHeader
                title={item.restaurantName}
                subheader={`Кухня: ${item.restaurantFood}`}
                image
              />

              <CardContent>
                <Typography>{item.restaurantDiscription}</Typography>
                <div className={cl.button}>
                  <Button
                    variant="contained"
                    onClick={() => navigate("/rest/" + item.restaurantId)}
                  >
                    Смотреть
                  </Button>
                </div>
              </CardContent>
            </Card>
          ))}
        </div>

        <div className={cl.pagination}>
          <Pagination
            onChange={onPageChange}
            count={pageCount}
            page={currentPage}
          />
        </div>
      </div>
    </section>
  );
};
