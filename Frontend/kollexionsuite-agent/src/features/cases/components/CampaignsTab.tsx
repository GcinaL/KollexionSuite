import Button from "../../../components/common/buttons/Button";
import Card from "../../../components/common/cards/Card";


export default function CampaignsTab() {

    return (
        <Card title="Campaigns" actions={<Button label="Create New" icon="isax isax-add" />}>
            <p>No data</p>
        </Card>
    );
}