import { type RouteConfig, index, layout } from "@react-router/dev/routes";

export default [
   layout("routes/main/layout.tsx", [
      index("routes/main/dashboard/dashboard.tsx"),
   ]),
] satisfies RouteConfig;
