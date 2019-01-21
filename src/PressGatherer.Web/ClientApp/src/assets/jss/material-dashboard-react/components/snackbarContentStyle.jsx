import {
  defaultFont,
  primaryBoxShadow,
  infoBoxShadow,
  successBoxShadow,
  warningBoxShadow,
  dangerBoxShadow,
  roseBoxShadow
} from "assets/jss/material-dashboard-react.jsx";

const snackbarContentStyle = {
  root: {
    ...defaultFont,
    flexWrap: "unset",
    position: "relative",
    padding: "20px 15px",
    lineHeight: "20px",
    marginBottom: "20px",
    fontSize: "14px",
    backgroundColor: "white",
    color: "#555555",
    borderRadius: "3px",
    boxShadow:
      "0 12px 20px -10px rgba(255, 255, 255, 0.28), 0 4px 20px 0px rgba(0, 0, 0, 0.12), 0 7px 8px -5px rgba(255, 255, 255, 0.2)"
  },
  top20: {
    top: "20px"
  },
  top40: {
    top: "40px"
  },
  info: {
      backgroundColor: "#381549",
    color: "#ffffff",
    ...infoBoxShadow
  },
  success: {
      backgroundColor: "#4BE299",
    color: "#ffffff",
    ...successBoxShadow
  },
  warning: {
      backgroundColor: "#C9B638",
    color: "#ffffff",
    ...warningBoxShadow
  },
  danger: {
      backgroundColor: "#C9388E",
    color: "#ffffff",
    ...dangerBoxShadow
  },
  primary: {
      backgroundColor: "#783996",
    color: "#ffffff",
    ...primaryBoxShadow
  },
  rose: {
      backgroundColor: "#1C6340",
    color: "#ffffff",
    ...roseBoxShadow
  },
  message: {
    padding: "0",
    display: "block",
    maxWidth: "89%"
  },
  close: {
    width: "11px",
    height: "11px"
  },
  iconButton: {
    width: "24px",
    height: "24px",
    padding: "0px"
  },
  icon: {
    display: "block",
    left: "15px",
    position: "absolute",
    top: "50%",
    marginTop: "-15px",
    width: "30px",
    height: "30px"
  },
  infoIcon: {
      color: "#381549"
  },
  successIcon: {
      color: "#4BE299"
  },
  warningIcon: {
      color: "#C9B638"
  },
  dangerIcon: {
      color: "#C9388E"
  },
  primaryIcon: {
      color: "#783996"
  },
  roseIcon: {
      color: "#1C6340"
  },
  iconMessage: {
    paddingLeft: "50px",
    display: "block"
  }
};

export default snackbarContentStyle;
