import { AppBar, IconButton, Toolbar, Typography } from "@mui/material";
import MenuIcon from "@mui/icons-material/Menu";

import cl from "./style.module.scss";
import { Link } from "react-router-dom";

export const Header = () => {
  return (
    <AppBar position="static" className={cl.bar}>
      <div className="container">
        <Typography variant="h4">
          <Link to="/">Restoplace</Link>
        </Typography>
        {/* <Toolbar>
          <IconButton>
            <MenuIcon color="action" />
          </IconButton>
        </Toolbar> */}
      </div>
    </AppBar>
  );
};
