import { AppBar, IconButton, Toolbar } from "@mui/material";

import MenuIcon from "@mui/icons-material/Menu";
import { Outlet } from "react-router";

const AppLayout = () => {
   return (
      <div className="w-full min-h-screen ">
         <AppBar position="static">
            <Toolbar>
               Social Events
            </Toolbar>
         </AppBar>
         <main>
            <Outlet />
         </main>
      </div>
   );
};

export default AppLayout;
