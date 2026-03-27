import Breadcrumb from '../../../components/common/Breadcrumbs/Breadcrumb'
import DropdownButton from '../../../components/common/dropdowns/DropdownButton'
import LinkButton from '../../../components/common/buttons/LinkButton'
import SectionTitle from '../../../components/common/labels/SectionTitle'
import { formatCurrency } from '../../../utils/formatters'
import CasesCard, { type CaseItem } from '../components/CasesCard'
import OverviewCard from '../components/OverviewCard'
import type { RankingItem } from '../components/RankingsCard'
import RankingsCard from '../components/RankingsCard'
import TargetsCard from '../components/TargetsCard'
import WelcomeBanner from '../components/WelcomeBanner'

export default function AgentDashboardView() {
    return (
        <>
            <Breadcrumb title="Dashboard">
                <LinkButton label='Start Collecting' href='/cases/assigned' variant='secondary' icon='fa fa-headset' iconPosition='start'/>
                <DropdownButton
                    label="Create New"
                    variant="primary"
                    items={[
                        { label: "PTP Arrangement", href: "/ptp/add", icon: "isax isax-wallet-check" },
                        { label: "Settlement Offer", href: "/account/settlement", icon: "isax isax-archive-book" },
                        { label: "Paid-up Letter", href: "/document/paid-up-letter", icon: "isax isax-document-text-1" },
                    ]}
                />
            </Breadcrumb>
            <WelcomeBanner />
            <div className='row'>
                <div className="col-md-12">
                    <SectionTitle title="Collections Overview" icon='isax isax-category5' />
                </div>
            </div>
            <div className='row'>
                <div className="col-md-8">
                    <div className='row'>
                        <div className="col-md-6 d-flex">
                            <OverviewCard title="Previous Month" items={lastMonthCollections} icon='isax isax-calendar-tick' />
                        </div>
                        <div className="col-md-6 d-flex">
                            <OverviewCard title="Current Month" items={currentMonthCollections} icon='isax isax-clock' />
                        </div>
                    </div>
                    <div className='row'>
                        <div className="col-md-12">
                            <TargetsCard
                                title="Monthly Collection Targets"
                                stats={[
                                    { label: "Target", value: formatCurrency(22000000, 0) },
                                    { label: "Received", value: formatCurrency(15000000, 0), color: "success" },
                                    { label: "Difference", value: formatCurrency(7000000, 0), color: "danger" },
                                ]}
                                legend={[
                                    { label: "Received", color: "primary" },
                                    { label: "Target", color: "dark" },
                                ]}
                                chart={{
                                    mode: "stacked",
                                    categories: ["May", "Jun", "Jul", "Aug", "Sep", "Oct"],
                                    series: [
                                    { name: "Received", data: [18562000, 21902458, 23125785, 24501100, 10000000, 15000000] },
                                    { name: "Outstanding", data: [3438000, 97542, 0, 0, 12000000, 7000000] },
                                    ],
                                    height: 364,
                                    showLegend: false,
                                    fractionDigits: 0,
                                }}
                            />
                        </div>
                    </div>
                </div>
                <div className="col-md-4">
                    <div className='row'>
                        <div className="col-md-12">
                            <CasesCard data={assignedCases}/>
                        </div>
                         <div className="col-md-12">
                           <RankingsCard title="Top Collectors" caption='September' rankings={rankings} />;
                         </div>
                    </div>
                </div>
            </div>
        </>
    )
}

const lastMonthCollections = [
    {
        label: "Invoices",
        value: "1,041",
        icon: "isax isax-document-text-1",
        bgClass: "bg-primary-subtle",
        textClass: "text-primary",
    },
    {
        label: "Customers",
        value: "3,462",
        icon: "isax isax-profile-2user",
        bgClass: "bg-success-subtle",
        textClass: "text-success-emphasis",
    },
    {
        label: "Amount Due",
        value: "$1,642",
        icon: "isax isax-dcube",
        bgClass: "bg-warning-subtle",
        textClass: "text-warning-emphasis",
    },
    {
        label: "Quotations",
        value: "2,150",
        icon: "isax isax-document-text",
        bgClass: "bg-info-subtle",
        textClass: "text-info-emphasis",
    },
];

const currentMonthCollections = [
    {
        label: "Invoices",
        value: "1,041",
        icon: "isax isax-document-text-1",
        bgClass: "bg-primary-subtle",
        textClass: "text-primary",
    },
    {
        label: "Customers",
        value: "3,462",
        icon: "isax isax-profile-2user",
        bgClass: "bg-success-subtle",
        textClass: "text-success-emphasis",
    },
    {
        label: "Amount Due",
        value: "$1,642",
        icon: "isax isax-dcube",
        bgClass: "bg-warning-subtle",
        textClass: "text-warning-emphasis",
    },
    {
        label: "Quotations",
        value: "2,150",
        icon: "isax isax-document-text",
        bgClass: "bg-info-subtle",
        textClass: "text-info-emphasis",
    },
]; 

const assignedCases: CaseItem[] = [
  { name: "25010001", status: "Broken PTP", amount: 3589 },
  { name: "25010002", status: "New case file", amount: 5426 },
  { name: "25010003", status: "New case file", amount: 1493 },
  { name: "25010004", status: "New case file", amount: 7854 },
  { name: "25010005", status: "New case file", amount: 4989 },
];

const rankings: RankingItem[] = [
  {
    id: "1",
    customerName: "Emily Clark",
    avatar: "/assets/img/users/user-02.jpg",
    amount: 12854,
    position: 1,
  },
  {
    id: "2",
    customerName: "David Anderson",
    avatar: "/assets/img/users/user-07.jpg",
    amount: 10500,
    position: 2,
  },
  {
    id: "3",
    customerName: "Sophia White",
    avatar: "/assets/img/users/user-16.jpg",
    amount: 9500,
    position: 3,
  }
];