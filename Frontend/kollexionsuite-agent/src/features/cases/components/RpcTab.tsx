import AccountOverview from "./AccountOverview";
import RightPartyContacts from "../../debtor/components/RightPartyContacts";
import Consents from "../../debtor/components/Consents";

export default function RpcTab() {

    return (
        <div className="row">
            <div className="col-lg-8 d-flex">
                <div className="row">
                    <div className="col-md-12 d-flex">
                        <RightPartyContacts />
                    </div>
                    <div className="col-md-12 d-flex">
                        <Consents />
                    </div>
                </div>
            </div>
            <div className="col-lg-4 d-flex">
                <AccountOverview />
            </div>
        </div>
    );
}