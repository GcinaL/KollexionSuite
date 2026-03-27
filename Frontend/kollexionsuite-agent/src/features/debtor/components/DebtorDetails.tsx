import Card from "../../../components/common/cards/Card";
import FormDataTable from "../../../components/common/tables/FormDataTable";

function DebtorDetails() {


  return (
    <div className='row'>
      <div className='col-lg-7'>
        <div className='row'>
          <div className='col-lg-12'>
            <Card title="Personal Details" overflow>
              <FormDataTable rows={personalDetails}/>
            </Card>
          </div>
          <div className='col-12'>
            <Card title="Contact Details" titleMargin='2' overflow>
               <FormDataTable rows={contactDetails}/>
            </Card>
          </div>
        </div>
      </div>
      <div className='col-lg-5 d-flex'>
        <Card title='Employment Details' overflow>
           <>
                <FormDataTable rows={employmentDetailsS1}/>
                <FormDataTable rows={employmentDetailsS2}/>
                <FormDataTable rows={employmentDetailsS3}/>
              </>
        </Card>
      </div>
    </div>
  )
}

export default DebtorDetails

 const personalDetails = [
   {
      cells: [
        { label: "Title", value: "Mr" },
        { label: "First Names", value: "Robert Charlse" },
        { label: "Surname", value: "George" },
        { label: "DOB", value: "15-11-1995", nowrap: true},
      ],
    },
    {
      cells: [
        { label: "ID No.", value: "9311156240089" },
        { label: "Identifier", value: "National Id" },
        { label: "Gender", value: "Male" },
        { label: "Nationality", value: "South African" },
      ],
    }
  ];


const contactDetails = [
  {
     cells: [
        { label: "Physical Address", isTitle: true},
        { label: "Postal Address", isTitle: true},
        { label: "Contacts Details", isTitle: true},
      ]
  },
   {
      cells: [
        { label: "Address", value: "1 umgololo street, Stand no 6039" },
        { label: "Address" },
        { label: "Cellphone", value: "+27715390177" },
      ],
    },
   {
      cells: [
         { label: "Suburb", value: "Kanyamazane-A" },
         { label: "Suburb"},
         { label: "Other"},
      ],
    }
  ,
   {
      cells: [
        { label: "Town", value: "Kanyamazane" },
        { label: "Town" },
        { label: "Email", value: "dlaminigcina@gmail.com" },
      ],
    },
    {
      cells: [
        { label: "Code", value: "1214" },
        { label: "Code", value:""},
      ],
    },
    {
      cells: [
        { label: "Country", value: "South Africa"},
      ],
    },
  ];

  const employmentDetailsS1 = [
   {
      cells: [
        { label: "Employer Name", value: "Madibane Technologies" },
      ],
    }
   
  ];

const employmentDetailsS2 = [
    {
       cells: [
        { label: "Physical Address", isTitle: true},
        { label: "Site Details", isTitle: true},
      ],
    },
    {
       cells: [
        { label: "Address", value:"501A New Consort"},
        { label: "Site", value:"Nelspruit H/O"},
      ],
    },
    {
       cells: [
        { label: "Suburb", value:"Consort Village"},
        { label: "Tel.", value:"01361001452"},
      ],
    },
     {
       cells: [
        { label: "Town", value:"Barberton"},
        { label: "Email", value:"info@madibanetech.co.za"},
      ],
    },
    {
       cells: [
        { label: "Code", value:"1201"},
       
      ],
    },
    {
       cells: [
        { label: "Country", value:"South Africa"},
      ],
    },
  ];

  const employmentDetailsS3 = [
    {
       cells: [
        { label: "Occupational Details", isTitle: true}
      ],
    },
   {
      cells: [
        { label: "Employee No.", value: "7512014" },
      ],
    },
    {
      cells: [
        { label: "Title", value: "Software Engineer" },
      ],
    },
   {
      cells: [
        { label: "Department", value: "I.T Department" },
      ],
    },
  ];